using Discord.Addons.Interactive;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Drawing;
using Discord;
using System.Linq;
using Discord.WebSocket;

namespace Anoda_Disasta
{
    public class SuperSpecialCommands : InteractiveBase
    {
        public string firstText;
        public string secondText;

        [Command("make-a-drake", RunMode = RunMode.Async)]
        public async Task MAD()
        {
            await ReplyAsync("What do you want to be bad?");
            var response = await NextMessageAsync();
            if (response != null) firstText = response.Content;
            else await ReplyAsync("You did not reply before the timeout");
            response = null;

            await ReplyAsync("What do you want to be good?");
            response = await NextMessageAsync();
            if (response != null) secondText = response.Content;
            else await ReplyAsync("You did not reply before the timeout");

            PointF firstLocation = new PointF(300f, 100f);
            PointF secondLocation = new PointF(300f, 450f);

            string imageFilePath = @"C:\Users\Me\Pictures\draketempate.bmp"; //Put your image here
            Bitmap bitmap = (Bitmap)System.Drawing.Image.FromFile(imageFilePath);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                using (Font arialFont = new Font("Arial", 24, FontStyle.Bold, GraphicsUnit.Point))
                {                    
                    RectangleF rectF1 = new RectangleF(300, 100, 225, 200);
                    graphics.DrawString(firstText, arialFont, Brushes.Black, rectF1);

                    RectangleF rectF2 = new RectangleF(300, 450, 225, 200);
                    graphics.DrawString(secondText, arialFont, Brushes.Black, rectF2);
                }
            }
            bitmap.Save(@"C:\Users\Me\Pictures\drakewt.png", System.Drawing.Imaging.ImageFormat.Png);

            await Context.Channel.SendFileAsync(@"C:\Users\Me\Pictures\drakewt.png"); //Put the place you want the edited image to save to here
        }
    }
}
