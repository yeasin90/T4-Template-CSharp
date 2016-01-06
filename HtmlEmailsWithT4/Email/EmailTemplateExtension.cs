namespace HtmlEmailsWithT4.Email
{
    using System;
    using System.Linq;

    public partial class EmailTemplate
    {
        public string Body { get; set; }

        private object _bodyTemplate;
        public object BodyTemplate
        {
            get { return _bodyTemplate; }
            set
            {
                // Get the type and the TransformText method using reflection
                var type = value.GetType();
                var method = type.GetMethod("TransformText");

                // Reflection signature checks
                if (method == null) throw new ArgumentException("BodyTemplate needs to be a RunTimeTemplate with a TransformText method");
                if (method.ReturnType != typeof(string) || method.GetParameters().Any()) throw new ArgumentException("Wrong TransformText signature on the BodyTemplate");

                // If everything is ok, assign the value
                _bodyTemplate = value;
            }
        }

        private string GetBodyText()
        {
            var result = string.Empty;

            // Use the BodyTemplate if available
            if(BodyTemplate != null)
            {
                dynamic castTemplate = BodyTemplate;
                result = castTemplate.TransformText();
            }
            // Otherwise use the Body string if it's not null or empty
            else if(!string.IsNullOrEmpty(Body))
            {
                result = Body;
            }

            return result;
        }
    }
}
