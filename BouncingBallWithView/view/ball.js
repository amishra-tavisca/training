window.ball = window.ball || {
    x : 100,
    y : 100,
    dx : 5,
    dy : 5

};


window.ball.initialise = function ()
{
    window.ball.resizeCanvas();  
    setInterval(window.ball.Bounce, 10);
}

window.ball.Bounce=function()
{
    context = document.getElementById("myCanvas").getContext('2d');     
    context.clearRect(0, 0, myCanvas.width, myCanvas.height);
    context.beginPath();
    context.fillStyle = "#0000ff";
    // Draws a circle of radius 20 at the coordinates 100,100 on the canvas
    context.arc(ball.x, ball.y, 20, 0, Math.PI * 2, true);
    context.closePath();
    context.fill();
    if (ball.x < 0 || ball.x > myCanvas.width) ball.dx = -ball.dx;
    if (ball.y < 0 || ball.y > myCanvas.height) ball.dy = -ball.dy;
    ball.x += ball.dx;
    ball.y += ball.dy;
}

