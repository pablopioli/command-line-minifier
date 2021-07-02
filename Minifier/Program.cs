using System;
using System.IO;
using NUglify;

namespace Minifier
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = args[0];

            var extension = Path.GetExtension(file);

            if (extension.Equals(".css", StringComparison.OrdinalIgnoreCase))
            {
                var css = File.ReadAllText(file);
                var minified = Uglify.Css(css);

                var minifiedFileName = Path.ChangeExtension(file, "min.css");
                File.WriteAllText(minifiedFileName, minified.ToString());
            }
            else if (extension.Equals(".js", StringComparison.OrdinalIgnoreCase))
            {
                var js = File.ReadAllText(file);
                var minified = Uglify.Js(js);

                var minifiedFileName = Path.ChangeExtension(file, "min.js");
                File.WriteAllText(minifiedFileName, minified.ToString());
            }
        }
    }
}
