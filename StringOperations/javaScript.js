String.prototype.Concat = function ()
{
    var firstString = this;
    var result = "";
    var index1 = 0;
    for (var count = 0; count < arguments.length; count++)
    {
        var secondString = arguments[count];

        if (typeof (secondString) == null || typeof (secondString) == undefined) {
            console.log("not a proper string !");
            return;
        }

        //var firstString = this;
        //var result = "";
        //var index1 = 0;
        if (count == 0) {
            for (index1 = 0; index1 < firstString.length; index1++)
                result += firstString.charAt(index1);
        }
        for (index1 = 0; index1 < secondString.length; index1++)
            result += secondString.charAt(index1);
        
    }
    console.log(result);

}

String.prototype.SubString = function (startIndex, endIndex) 
{
   var firstString = this;
   if ((startIndex > endIndex) || endIndex >= this.length) 
   {
       console.log("Invalid Index");
       return;
   }
   var result = "";
   if (startIndex > endIndex || startIndex > firstString.length || endIndex > firstString.length)
       console.log("invalid index");
   for (; startIndex < endIndex; startIndex++)
   {
       result += firstString.charAt(startIndex);
   }
   console.log(result);
}