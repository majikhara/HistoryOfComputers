$(document).ready(function () {
    msg1 = 'In a world where technology is so readly available, it is easy to forget that it has not always been this way.';
    msg2 = 'Computers have had a long journey to reach the processing capability they have achieved.' 
    msg3 = 'Delve into the journey that brought computers from calculators and war machines to the personal computer we know today.';
    
    var options1 = {
        onAfterType: function () { $("#secondline").coolType(msg2, options2); },
        delayAfterType: 0
        //expansions: ['&#13;','&#10;']
    };
    var options2 = {
        onAfterType: function () { $("#thirdline").coolType(msg3); },
        delayAfterType: 0
    };
    $("#firstline").coolType(msg1, options1);
    /*$("#secondline").coolType(msg2);*/
});