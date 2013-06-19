var chartClick = "";

function ShowBarGraph() {
    var myLine = new Chart(document.getElementById("myChart").getContext("2d")).Bar(ChartData);
    chartClick = "Bar";
}

function ShowLineGraph() {
    var myLine = new Chart(document.getElementById("myChart").getContext("2d")).Line(ChartData);
    chartClick = "Line";
}

function ShowRadarGraph() {
    var myLine = new Chart(document.getElementById("myChart").getContext("2d")).Radar(ChartData, { scaleShowLabels: false, pointLabelFontSize: 10 });
    chartClick = "Radar";
}

$(document).ready(function () {

    //Get the canvas & context
    var c = $('#myChart');
    var ct = c.get(0).getContext('2d');
    var container = $(c).parent();

    //Run function when browser  resize
    $(window).resize(respondCanvas);

    function respondCanvas() {
        c.attr('width', $(container).width()); //max width
        c.attr('height', $(container).height()); //max height

        //Redraw & reposition content
        var x = c.width();
        var y = c.height();
        ct.font = "20px Calibri";

        ct.fillStyle = "#DDDDDD"; //black
        ct.fillRect(0, 0, x, y); //fill the canvas

        var resizeText = "Chart.JS";
        ct.textAlign = "center";
        ct.fillStyle = "#333333"; //white
        ct.fillText(resizeText, (x / 2), (y / 2));

        switch (chartClick) {
            case "Bar":
                ShowBarGraph(); break;
            case "Line":
                ShowLineGraph(); break;
            case "Radar":
                ShowRadarGraph(); break;
        }
    }

    respondCanvas();
});