$(document).ready(function () {
    msg1 = '> In a world where technology has taken over, we can sometimes forget our roots. ';
    msg2 = '> With this site, our goal is to give everyone a window into the past, to see the origin of computers to give us a further appreciation for what we have, and perhaps nostalgia for others.' 
    msg3 = '> Line 3';
    var options1 = {
        onAfterType: function () { $("#secondline").coolType(msg2, options2); },
        delayAfterType: 0
    };
    var options2 = {
        onAfterType: function () { $("#thirdline").coolType(msg3); },
        delayAfterType: 0
    };
    $("#firstline").coolType(msg1, options1);
    /*$("#secondline").coolType(msg2);*/
});