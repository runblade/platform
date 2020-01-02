import React, { Component } from 'react';
import axios from 'axios';

export class Home extends Component {
    state = {
        error: null,
        isLoaded: false,
        items: []
    };

    //Some class variables go here
    urlAPIDevices = 'https://virtserver.swaggerhub.com/runblade/rb-ingestor/1.0.0/devices';
    
    componentDidMount() {
        axios.get(this.urlAPIDevices).then(
            result => {
                console.log(result);
                this.setState({
                    isLoaded: true,
                    items: result.data
                });
            },
            // Note: it's important to handle errors here
            // instead of a catch() block so that we don't swallow
            // exceptions from actual bugs in components.
            error => {
                this.setState({
                    isLoaded: true,
                    error
                });
            }
        );
    }

    render() {
        const {
            error, isLoaded, items
        } = this.state;
        if (error) {
            return <div>Error: {error.message}</div>;
        }
        else if (!isLoaded) {
            return <div>Loading...</div>;
        }
        else {
            return (
                //Ideally this will auto-generate from the API's JSON return
                <div>
                    <h1>
                        {this.urlAPIDevices}
                    </h1>
                    <table>
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>LOCATIONID</th>
                                <th>PROTOCOL</th>
                                <th>URI</th>
                            </tr>
                        </thead>
                        <tbody>
                            {/* Shamelessly repeated to simulate multiple rows */}
                            {items.map(item =>
                                <tr key={item.id}>
                                    <td>{item.id}</td>
                                    <td>{item.locationId}</td>
                                    <td>{item.protocol}</td>
                                    <td>{item.uri}</td>
                                </tr>
                            )}
                            {items.map(item =>
                                <tr key={item.id}>
                                    <td>{item.id}</td>
                                    <td>{item.locationId}</td>
                                    <td>{item.protocol}</td>
                                    <td>{item.uri}</td>
                                </tr>
                            )}
                            {items.map(item =>
                                <tr key={item.id}>
                                    <td>{item.id}</td>
                                    <td>{item.locationId}</td>
                                    <td>{item.protocol}</td>
                                    <td>{item.uri}</td>
                                </tr>
                            )}
                        </tbody>
                    </table>
                </div>
            );
        }
    }
}