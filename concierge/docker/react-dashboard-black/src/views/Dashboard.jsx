//Black Dashboard React v1.0.0
//Product Page: https://www.creative-tim.com/product/black-dashboard-react
// Copyright 2019 Creative Tim (https://www.creative-tim.com)
//Licensed under MIT (https://github.com/creativetimofficial/black-dashboard-react/blob/master/LICENSE.md)
//Coded by Creative Tim
//The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

//----------------------------
//Modified by SR Runblade 2020
//----------------------------

import React from "react";
//NodeJS library that concatenates classes
import classNames from "classnames";
//React plugin used to create charts
import { Line, Bar } from "react-chartjs-2";
//Axios for JSON processing
import axios from 'axios';

// reactstrap components
import {
  Button,
  ButtonGroup,
  Card,
  CardHeader,
  CardBody,
  CardTitle,
  DropdownToggle,
  DropdownMenu,
  DropdownItem,
  UncontrolledDropdown,
  Label,
  FormGroup,
  Input,
  Table,
  Row,
  Col,
  UncontrolledTooltip
} from "reactstrap";

// core components
import {
  chartExample1,
  chartExample2,
  chartExample3,
  chartExample4
} from "variables/charts.jsx";

class Dashboard extends React.Component {

  //Class variables go here
  urlAPIDevices = 'https://virtserver.swaggerhub.com/runblade/rb-ingestor/1.0.0/devices';
  constructor(props) {
    super(props);
    this.state = {
      bigChartData: "data1",
      isLoaded: false,
      items: null
    };
  }

  setBgChartData = name => {
    this.setState({
      bigChartData: name
    });
  };

  getAPIDataDevices() {
    let tableRows = [];

    for (let i=0; i<9; i++) {
      for (let item of this.state.items) {
        tableRows.push(
          <tr key={item.id.substring(0,5)}>
            <td>{item.id.substring(0,5)}</td>
            <td>{item.locationId.substring(0,5)}</td>
            <td>{item.protocol}</td>
            <td>{item.uri}</td>
          </tr>  
        );
      }
    }
    return tableRows;
  }

  getAPICreatives() {
    let tableRows = [];
    for (let i=0; i<24; i++) {
      tableRows.push(
        <tr>
          <td>
            <FormGroup check>
              <Label check>
                <Input defaultValue="" type="checkbox" />
                <span className="form-check-sign">
                  <span className="check" />
                </span>
              </Label>
            </FormGroup>
          </td>
          <td>
            <p className="title">Creative Submission</p>
            <p className="text-muted">
              Location, City, State, DateTime 00:00 AM
            </p>
          </td>
        </tr>
      );
    }
    return tableRows;
  }
    
  componentDidMount() {
    //Get data for certain portions of this Dashboard
    console.log('DEBUG: Dashboard.jsx componentDidMount()');
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
    console.log('DEBUG: Dashboard.jsx render()');
    console.log(this.state);
    return (
      <>
        <div className="content">
          <Row>
            <Col lg="4">
              <Card className="card-chart">
                <CardHeader>
                  <h5 className="card-category">Total Devices</h5>
                  <CardTitle tag="h3">
                    <i className="tim-icons icon-bell-55 text-info" />{" "}
                    763,215
                  </CardTitle>
                </CardHeader>
                <CardBody>
                  <div className="chart-area">
                    <Line
                      data={chartExample2.data}
                      options={chartExample2.options}
                    />
                  </div>
                </CardBody>
              </Card>
            </Col>
            <Col lg="4">
              <Card className="card-chart">
                <CardHeader>
                  <h5 className="card-category">Daily Placements</h5>
                  <CardTitle tag="h3">
                    <i className="tim-icons icon-delivery-fast text-primary" />{" "}
                    USD 3,500
                  </CardTitle>
                </CardHeader>
                <CardBody>
                  <div className="chart-area">
                    <Bar
                      data={chartExample3.data}
                      options={chartExample3.options}
                    />
                  </div>
                </CardBody>
              </Card>
            </Col>
            <Col lg="4">
              <Card className="card-chart">
                <CardHeader>
                  <h5 className="card-category">Creatives Submitted</h5>
                  <CardTitle tag="h3">
                    <i className="tim-icons icon-send text-success" /> 12,100K
                  </CardTitle>
                </CardHeader>
                <CardBody>
                  <div className="chart-area">
                    <Line
                      data={chartExample4.data}
                      options={chartExample4.options}
                    />
                  </div>
                </CardBody>
              </Card>
            </Col>
          </Row>
          <Row>
            <Col lg="6" md="12">
              <Card>
                <CardHeader>
                  <CardTitle tag="h6">Latest Devices</CardTitle>
                </CardHeader>
                <CardBody>
                  {/* New dynamic table */}
                  {this.state.isLoaded &&
                    <Table className="tablesorter">
                      <thead className="text-primary">
                        {/*
                        <tr>
                          <th>ID</th>
                          <th>LOCATIONID</th>
                          <th>PROTOCOL</th>
                          <th>URI</th>
                        </tr>
                        */}
                      </thead>
                      <tbody>
                        {this.getAPIDataDevices()}
                      </tbody>
                    </Table>
                  }
                </CardBody>
              </Card>
            </Col>
            <Col lg="6" md="12">
              <Card className="card-tasks" style={{height: 95 + '%'}}>
                <CardHeader>
                  <h6 className="title d-inline">Approvals</h6>
                  <p className="card-category d-inline"> today</p>
                  <UncontrolledDropdown>
                    <DropdownToggle
                      caret
                      className="btn-icon"
                      color="link"
                      data-toggle="dropdown"
                      type="button"
                    >
                      <i className="tim-icons icon-settings-gear-63" />
                    </DropdownToggle>
                    <DropdownMenu aria-labelledby="dropdownMenuLink" right>
                      <DropdownItem
                        href="#pablo"
                        onClick={e => e.preventDefault()}
                      >
                        Action 1
                      </DropdownItem>
                      <DropdownItem
                        href="#pablo"
                        onClick={e => e.preventDefault()}
                      >
                        Action 2
                      </DropdownItem>
                      <DropdownItem
                        href="#pablo"
                        onClick={e => e.preventDefault()}
                      >
                        Action 3
                      </DropdownItem>
                    </DropdownMenu>
                  </UncontrolledDropdown>
                </CardHeader>
                <CardBody>
                  <div className="table-full-width table-responsive">
                    <Table>
                      <tbody>
                        {this.getAPICreatives()}
                      </tbody>
                    </Table>
                  </div>
                </CardBody>
              </Card>
            </Col>
          </Row>
        </div>
      </>
    );
  }
}

export default Dashboard;
