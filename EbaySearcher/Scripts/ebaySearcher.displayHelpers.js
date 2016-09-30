var displayHelper = new function () {
    var roundForMoney = function (number) {
        return (Math.round(number*Math.pow(10,2))/Math.pow(10,2)).toFixed(2);
    };
        
    return {
        roundForMoney: roundForMoney
    };
}