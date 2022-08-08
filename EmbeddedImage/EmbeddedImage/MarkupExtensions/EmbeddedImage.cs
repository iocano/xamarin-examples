using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmbeddedImage.MarkupExtensions
{
    // Allows use of extension without expecify ResourceId attribute explicitly
    [ContentProperty("ResourceId")]
    internal class EmbeddedImage : IMarkupExtension
    {
        public string ResourceId { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return string.IsNullOrWhiteSpace(ResourceId) 
                ? null 
                : ImageSource.FromResource(ResourceId);
        }
    }
}
