using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Collections.Concurrent;
using System.Web.Mvc;
using System.Drawing;
using Orchard.Mvc.Html;

public static class ImageHelpers
{
    static readonly ConcurrentDictionary<string, Tuple<int, int>> ImageCache = 
                    new ConcurrentDictionary<string, Tuple<int,int>>(StringComparer.OrdinalIgnoreCase);

    public static IHtmlString ResizedImage(this HtmlHelper html, string src, int maxWidth, int maxHeight)
    {
        Tuple<int, int> dimensions;
        if(!ImageCache.TryGetValue(src, out dimensions))
        {
            var imgPath = html.ViewContext.RequestContext.HttpContext.Server.MapPath(src);
            if(!File.Exists(imgPath))
            {
                return html.Image(src, "", new {width = maxWidth, height = maxHeight});
            }

            using(var img = Image.FromFile(imgPath))
            {
                dimensions = new Tuple<int, int>(img.Width, img.Height);
                ImageCache.TryAdd(src, dimensions);
            }
        }
        
        int actualWidth = dimensions.Item1, actualHeight = dimensions.Item2;

        int w = actualWidth, h = actualHeight; 
        if(h > maxHeight || w > maxWidth)
        {
            w = (int) (actualWidth*1.0*maxHeight/actualHeight);
            h = maxHeight; 
            if(w > maxWidth)
            {
                h = (int) (actualHeight*1.0*maxWidth/actualWidth);
                w = maxWidth;
            }
        }

        return html.Image(src, "", new {width = w, height = h});
    }
}
