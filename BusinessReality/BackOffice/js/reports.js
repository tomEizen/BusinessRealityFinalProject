var plot5
var plot6
var plot7

//show a specific div in the page and hides the rest
function show(target) {
    $('#general').hide();
    $('#demographics').hide();
    $('#act').hide();
    $('#campaign').hide();
    $('#' + target).fadeIn(1300);
    if (target == 'campaign') {
        plot5.replot();
        plot6.replot();
        plot7.replot();
    }
}

//show a specific div in the page and hides the rest
function setupProductViews(containerElementId) {
    var s1 = [200, 300, 400, 500, 600, 700, 800, 900, 1000];
    var s2 = [190, 290, 390, 490, 590, 690, 790, 890, 990];
    var s3 = [250, 350, 450, 550, 650, 750, 850, 950, 1050];
    var s4 = [2000, 1600, 1400, 1100, 900, 800, 1550, 1950, 1050];
    var s5 = [2000, 1600, 1400, 1100, 900, 800, 1550, 1950, 1050];
    // Can specify a custom tick Array.
    // Ticks should match up one for each y value (category) in the series.
    var ticks = ['8:00', '10:00', '12:00', '14:00', '16:00', '20:00', '22:00'];
    var amount = ['0', '200', '400', '600', '800', '1000', '2000', '4000'];
    var plot1 = $.jqplot(containerElementId, [s1, s2, s3, s4, s5, ], {
        // The "seriesDefaults" option is an options object that will
        // be applied to all series in the chart.
        seriesDefaults: {
            renderer: $.jqplot.BarRenderer,
            rendererOptions: { fillToZero: true }
        },
        // Custom labels for the series are specified with the "label"
        // option on the series option.  Here a series option object
        // is specified for each series.
        series: [
            { label: 'מכנס' },
            { label: 'חולצה' },
            { label: 'חולצה מכופתרת' },
            { label: 'חולצת וי' },
              { label: 'חולצת מכנס אלגנט' }
        ],
        // Show the legend and put it outside the grid, but inside the
        // plot container, shrinking the grid to accomodate the legend.
        // A value of "outside" would not shrink the grid and allow
        // the legend to overflow the container.
        legend: {
            show: true,
            placement: 'outsideGrid'
        },
        axes: {
            // Use a category axis on the x axis and use our custom ticks.
            xaxis: {
                renderer: $.jqplot.CategoryAxisRenderer,
                ticks: ticks
            },
            // Pad the y axis just a little so bars can get close to, but
            // not touch, the grid boundaries.  1.2 is the default padding.
            yaxis: {
                pad: 1.05

            }
        }
    });
}


//draw gender plot
function drawGenderChart(containerElement, male, female) {
    var plot3 = $.jqplot(containerElement,
    [[['נשים', parseInt(female)], ['גברים', parseInt(male)]]],
    {
        title: ' ',
        seriesDefaults: {
            shadow: true,
            renderer: jQuery.jqplot.PieRenderer,
            rendererOptions: {
                dataLabels: ['percent'],
                startAngle: 180,
                sliceMargin: 4,
                showDataLabels: true
            }
        },
        legend: { show: true, location: 'e' }
    }
  );

}

//draw pie chart to represent the age ranges of the useres 
function drawAgesChart(containerElement, range1, range2, range3, range4, range5, range6, range7, range8) {
    plot1 = jQuery.jqplot(containerElement,
    [[['0-12', parseInt(range1)], ['13-17', parseInt(range2)], ['18-24', parseInt(range3)], ['25-34', parseInt(range4)], ['35-44', parseInt(range5)], ['45-54', parseInt(range6)], ['55-64', parseInt(range7)], ['65+', parseInt(range8)], ]],
    {
        title: ' ',
        seriesDefaults: {
            shadow: true,
            renderer: jQuery.jqplot.PieRenderer,
            rendererOptions: {
                dataLabels: ['percent'],
                startAngle: 180,
                sliceMargin: 4,
                showDataLabels: true
            }
        },
        legend: { show: true, location: 'e' }
    }
  );
}

//draw a bar chart to represent the top 5 campaign
function drawCamgaignShareChart(containerElement, name1, share1, name2, share2, name3, share3, name4, share4, name5, share5) {

    $.jqplot.config.enablePlugins = true;
    var line1 = [[name1.toString(), parseInt(share1)], [name2.toString(), parseInt(share2)], [name3.toString(), parseInt(share3)],
  [name4.toString(), parseInt(share4)], [name5.toString(), parseInt(share5)]];

    plot5 = $.jqplot(containerElement, [line1],
   {
       width: '700px',
       title: '',
       series: [{ renderer: $.jqplot.BarRenderer}],
       axesDefaults: {
           tickRenderer: $.jqplot.AxisTickRenderer,
           tickOptions: {
               mark: 'inside',
               showMark: true,
               markSize: 4,
               showLabel: true,
               showTicks: true,
               showTickMarks: true,
               angle: -25,
               fontSize: '10pt'


           }
       },
       pointLabels: { show: true },

       axes: {
           xaxis: {

               renderer: $.jqplot.CategoryAxisRenderer

           },
           highlighter: {
               sizeAdjust: 7.5
           },
           cursor: {
               show: true
           }
       }
   }
  );
}


//draw pie chart to represent the age ranges of the useres who shared a campaign
function drawCampaignShareAgesChart(containerElement, range1, range2, range3, range4, range5, range6, range7, range8) {
    plot6 = jQuery.jqplot(containerElement,
    [[['0-12', parseInt(range1)], ['13-17', parseInt(range2)], ['18-24', parseInt(range3)], ['25-34', parseInt(range4)], ['35-44', parseInt(range5)], ['45-54', parseInt(range6)], ['55-64', parseInt(range7)], ['65+', parseInt(range8)], ]],
    {
        width: '480px',
        title: ' ',
        seriesDefaults: {
            shadow: true,
            renderer: jQuery.jqplot.PieRenderer,
            rendererOptions: {
                dataLabels: ['percent'],
                startAngle: 180,
                sliceMargin: 4,
                showDataLabels: true
            }
        },
        legend: { show: true, location: 'e' }
    }
  );
}



//draw pie chart to represent the gender of the users who shared a campaign
function drawCampaignShareGenderChart(containerElement, male, female) {
    plot7 = $.jqplot(containerElement,
    [[['נשים', parseInt(female)], ['גברים', parseInt(male)]]],
    {
        width: '480px',
        title: ' ',
        seriesDefaults: {
            shadow: true,
            renderer: jQuery.jqplot.PieRenderer,
            rendererOptions: {
                dataLabels: ['percent'],
                startAngle: 180,
                sliceMargin: 4,
                showDataLabels: true
            }
        },
        legend: { show: true, location: 'e' }
    }
  );
}

//onload

$(document).ready(function () {
    $('#demographicsBtn').click(function () {
        drawBubbleChart('bubble-chart');
    });
    setupLeftMenu();
    setSidebarHeight();
});