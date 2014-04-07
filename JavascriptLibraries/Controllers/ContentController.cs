using System;
using System.Threading;
using System.Web.Mvc;

namespace JavascriptLibraries.Controllers
{
    public class ContentController : AsyncController
    {
        public ContentResult Random()
        {
            var rand = new Random();

            Thread.Sleep(rand.Next(0, 4)*1000);

            var content = new []
            {
                "<img src=\"http://placekitten.com/1140/400\" alt=\"\" class=\"img-responsive\">",
                "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam bibendum egestas dui at viverra. Maecenas vehicula nec nisi sed condimentum. Interdum et malesuada fames ac ante ipsum primis in faucibus. Fusce at mi nec orci convallis sagittis. Donec in nisi ac nisi elementum fermentum. Donec nulla est, consectetur sed purus dictum, dapibus interdum augue. Ut placerat porta leo non posuere. Maecenas nec est sed eros imperdiet commodo. Nulla tempor, enim at commodo sagittis, enim erat faucibus justo, ut sollicitudin augue nisl iaculis arcu. Aenean feugiat quam sed ligula malesuada bibendum.</p>",
                "<p>Vestibulum ullamcorper odio sit amet placerat euismod. Nulla non urna porttitor, condimentum libero a, molestie turpis. Maecenas bibendum velit vitae leo tempus ornare. Curabitur varius porta dolor ac vestibulum. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur tristique sem at nibh vestibulum ultrices. Morbi a neque vitae est elementum congue vulputate ut arcu. Pellentesque tempor nulla ac nisl congue laoreet eu ac tellus.</p>",
                "<img src=\"http://placekitten.com/1240/400\" alt=\"\" class=\"img-responsive\">",
                "<p>Sed ac orci diam. Suspendisse ac mauris mauris. Phasellus commodo laoreet justo in luctus. Nam blandit lobortis risus sit amet condimentum. Vestibulum eget ultricies eros, vel dictum neque. Cras vel nunc nec ante imperdiet iaculis. Duis eget odio vel turpis tincidunt faucibus. Maecenas eu nunc tempor, consectetur nibh at, ornare enim. Donec consectetur lobortis ante, sit amet pharetra elit tempus nec. Nullam vel dolor sed nibh interdum laoreet ut non ligula. Sed vehicula convallis risus, sit amet porta est laoreet sit amet. Cras varius est ipsum, nec ullamcorper velit posuere et. Mauris facilisis a odio vel ultrices. Suspendisse dictum est metus. Nunc ultricies viverra neque id auctor. Nunc mattis interdum eleifend.</p>",
                "<p><strong>Lazy loading</strong> is a design pattern commonly used in computer programming to defer initialization of an object until the point at which it is needed. It can contribute to efficiency in the program's operation if properly and appropriately used. The opposite of lazy loading is eager loading.</p>",
                "<img src=\"http://placekitten.com/1340/400\" alt=\"\" class=\"img-responsive\">",
            };

            return Content(content[rand.Next(content.Length-1)]);
        }
    }
}