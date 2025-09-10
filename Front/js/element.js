//#region Chart

// Chart information class.
class ChartInfo {
    constructor(chart, data) {
        this.Chart = chart;
        this.Data = data;
    }
}

function Initialize_ChartInfo(chartID) {

    // Create the data format.
    const data = {
        labels: [],
        datasets: [{
            label: 'X-axis',
            data: [],
            fill: false,
            borderColor: '#1E90FF', // Setting the line color.
            tension: 0.1
        }, {
            label: 'Y-axis',
            data: [],
            fill: false,
            borderColor: '#FF8C00', // Setting the line color.
            tension: 0.1
        }, {
            label: 'Z-axis',
            data: [],
            fill: false,
            borderColor: '#CD853F', // Setting the line color.
            tension: 0.1
        }]
    };

    // Get the element from the RMS
    const ctx = document.getElementById(chartID);

    // Setting the config.
    const config = {
        type: 'line',
        data: data,
        options: {
            animation: {
                duration: 0 // 禁用動畫，更新即時生效
            },
            responsive: true,
            maintainAspectRatio: true, // 禁用比例維持
            plugins: {
                title: {
                    display: true,
                    text: 'RMS'
                },
            },
            interaction: {
                intersect: false,
            },
            scales: {
                x: {
                    display: true,
                    title: {
                        display: true,
                        text: 'Index'
                    }
                },
                y: {
                    display: true,
                    title: {
                        display: true,
                        text: 'Value. (g)'
                    },

                    suggestedMin: -200,
                    suggestedMax: 200
                }
            }
        },
    };

    return new ChartInfo(new Chart(ctx, config), data);
}


//#endregion