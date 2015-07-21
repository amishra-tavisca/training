window.ball = window.ball || {}
window.ball.resizeCanvas= function ()
{
    canvas = document.getElementById("myCanvas");
    canvas.width = window.innerWidth;
    canvas.height = window.innerHeight;
    window.ball.Bounce();
}

