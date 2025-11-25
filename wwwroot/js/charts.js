// Chart.js helper functions for Task Management Dashboard

window.chartInstances = {
    categoryChart: null,
    trendChart: null
};

// Initialize Category Distribution Pie Chart
window.initCategoryChart = function (categories, taskCounts) {
    const ctx = document.getElementById('categoryChart');
    if (!ctx) return;

    // Destroy existing chart if it exists
    if (window.chartInstances.categoryChart) {
        window.chartInstances.categoryChart.destroy();
    }

    const colors = [
        '#4a90e2', '#e74c3c', '#2ecc71', '#f39c12', 
        '#9b59b6', '#1abc9c', '#34495e', '#e67e22',
        '#3498db', '#95a5a6'
    ];

    window.chartInstances.categoryChart = new Chart(ctx, {
        type: 'pie',
        data: {
            labels: categories,
            datasets: [{
                data: taskCounts,
                backgroundColor: colors.slice(0, categories.length),
                borderWidth: 2,
                borderColor: '#fff'
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: true,
            plugins: {
                legend: {
                    position: 'bottom',
                    labels: {
                        padding: 15,
                        font: {
                            size: 12
                        }
                    }
                },
                title: {
                    display: true,
                    text: 'Tasks by Category',
                    font: {
                        size: 16,
                        weight: 'bold'
                    },
                    padding: {
                        top: 10,
                        bottom: 20
                    }
                },
                tooltip: {
                    callbacks: {
                        label: function(context) {
                            const label = context.label || '';
                            const value = context.parsed || 0;
                            const total = context.dataset.data.reduce((a, b) => a + b, 0);
                            const percentage = ((value / total) * 100).toFixed(1);
                            return `${label}: ${value} tasks (${percentage}%)`;
                        }
                    }
                }
            }
        }
    });
};

// Initialize Completion Trend Line Chart
window.initTrendChart = function (dates, completedCounts, createdCounts) {
    const ctx = document.getElementById('trendChart');
    if (!ctx) return;

    // Destroy existing chart if it exists
    if (window.chartInstances.trendChart) {
        window.chartInstances.trendChart.destroy();
    }

    window.chartInstances.trendChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: dates,
            datasets: [
                {
                    label: 'Tasks Completed',
                    data: completedCounts,
                    borderColor: '#2ecc71',
                    backgroundColor: 'rgba(46, 204, 113, 0.1)',
                    tension: 0.4,
                    fill: true,
                    pointRadius: 4,
                    pointHoverRadius: 6,
                    pointBackgroundColor: '#2ecc71',
                    pointBorderColor: '#fff',
                    pointBorderWidth: 2
                },
                {
                    label: 'Tasks Created',
                    data: createdCounts,
                    borderColor: '#4a90e2',
                    backgroundColor: 'rgba(74, 144, 226, 0.1)',
                    tension: 0.4,
                    fill: true,
                    pointRadius: 4,
                    pointHoverRadius: 6,
                    pointBackgroundColor: '#4a90e2',
                    pointBorderColor: '#fff',
                    pointBorderWidth: 2
                }
            ]
        },
        options: {
            responsive: true,
            maintainAspectRatio: true,
            interaction: {
                mode: 'index',
                intersect: false
            },
            plugins: {
                legend: {
                    position: 'bottom',
                    labels: {
                        padding: 15,
                        font: {
                            size: 12
                        },
                        usePointStyle: true
                    }
                },
                title: {
                    display: true,
                    text: '30-Day Task Activity Trend',
                    font: {
                        size: 16,
                        weight: 'bold'
                    },
                    padding: {
                        top: 10,
                        bottom: 20
                    }
                },
                tooltip: {
                    backgroundColor: 'rgba(0, 0, 0, 0.8)',
                    padding: 12,
                    titleFont: {
                        size: 14
                    },
                    bodyFont: {
                        size: 13
                    },
                    callbacks: {
                        label: function(context) {
                            return `${context.dataset.label}: ${context.parsed.y} tasks`;
                        }
                    }
                }
            },
            scales: {
                y: {
                    beginAtZero: true,
                    ticks: {
                        stepSize: 1,
                        font: {
                            size: 11
                        }
                    },
                    grid: {
                        color: 'rgba(0, 0, 0, 0.05)'
                    }
                },
                x: {
                    ticks: {
                        font: {
                            size: 11
                        },
                        maxRotation: 45,
                        minRotation: 45
                    },
                    grid: {
                        display: false
                    }
                }
            }
        }
    });
};

// Destroy all charts (useful for cleanup)
window.destroyCharts = function () {
    if (window.chartInstances.categoryChart) {
        window.chartInstances.categoryChart.destroy();
        window.chartInstances.categoryChart = null;
    }
    if (window.chartInstances.trendChart) {
        window.chartInstances.trendChart.destroy();
        window.chartInstances.trendChart = null;
    }
};
