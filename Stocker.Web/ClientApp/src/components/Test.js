import React, { Component } from 'react';

import { Button } from 'antd';

import { Line } from 'react-chartjs-2';

export class Test extends Component {
    static displayName = Test.name;

    constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true };
    }

    componentDidMount() {
        this.populateWeatherData();
    }

    async populateWeatherData() {
        const response = await fetch('stock/GME');
        const data = await response.json();

        console.log(data);
        this.setState({ forecasts: data, loading: false });
    }

    render() {

        var forecasts = this.state.forecasts;

        var data = {};
        var options = {};

        if (!this.state.loading) {
            data = {
                labels: forecasts.lines.map(f => (new Date(f.timeStamp).toLocaleDateString('en-US'))),
                datasets: [
                    {
                        label: "Open",
                        data: forecasts.lines.map(f => (f.open)),
                        fill: false,
                        backgroundColor: 'red',
                        borderColor: 'red',
                    },
                    {
                        label: "Close",
                        data: forecasts.lines.map(f => (f.close)),
                        fill: false,
                        backgroundColor: 'blue',
                        borderColor: 'blue',
                    },
                    {
                        label: "Low",
                        data: forecasts.lines.map(f => (f.low)),
                        fill: false,
                        backgroundColor: 'orange',
                        borderColor: 'orange',
                    },
                    {
                        label: "High",
                        data: forecasts.lines.map(f => (f.high)),
                        fill: false,
                        backgroundColor: 'green',
                        borderColor: 'green',
                    }
                ]
            };

            options = {
                title: {
                    display: true,
                    text: forecasts.symbol
                },
                tooltips: {
                    mode: 'index'
                }
            }
        }

        return (<>
            <div className='header'>
                <h1 className='title'>Line Chart</h1>
                <div className='links'>
                    <a
                        className='btn btn-gh'
                        href='https://github.com/reactchartjs/react-chartjs-2/blob/react16/example/src/charts/Line.js'
                    >
                        Github Source
        </a>
                </div>
            </div>
            <Line data={data} options={options} />
        </>
    )
  }
}
