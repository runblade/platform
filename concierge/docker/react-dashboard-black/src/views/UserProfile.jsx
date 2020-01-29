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
import axios from 'axios';
import NotificationAlert from "react-notification-alert";

//Reactstrap components
import {
  Button,
  Card,
  CardHeader,
  CardBody,
  CardFooter,
  CardText,
  FormGroup,
  Form,
  Input,
  Row,
  Col
} from "reactstrap";

class UserProfile extends React.Component {
  //Class variables go here
  constructor(props) {
    super(props);
    this.state = {
      form_email: ''
    };
  }
  handleChange = event => {
    event.preventDefault();
    console.log('UserProfile.jsx handleChange...');
    this.setState({ form_email: event.target.value });
  }
  handleSubmit = event => {
    event.preventDefault();
    console.log('UserProfile.jsx handleSubmit...');
    const payload = {
      email: this.state.form_email
    }
    console.log(payload)    
    axios.post('https://virtserver.swaggerhub.com/runblade/rb-ingestor/1.0.0/devices/register', payload)
      .then(res => {
        console.log(res);
        console.log(res.data);
        //Notification would be based on return result
        this.notify("tc");
      });
  }
  notify = place => {
    var options = {};
    options = {
      place: place,
      message: (
        <div>
          <div>
            Your form was successfully submitted.
          </div>
        </div>
      ),
      type: 'success',
      icon: "tim-icons icon-bell-55",
      autoDismiss: 7
    };
    this.refs.notificationAlert.notificationAlert(options);
  };
  render() {
    return (
      <>
        <div className="content">
          <div className="react-notification-alert-container">
            <NotificationAlert ref="notificationAlert" />
          </div>
          <Row>
            <Col md="6">
              <Card className="card-user" style={{height: 94 + '%'}}>
                <CardBody>
                  <CardText />
                  <div className="author">
                    <div className="block block-one" />
                    <div className="block block-two" />
                    <div className="block block-three" />
                    <div className="block block-four" />
                    <a href="#pablo" onClick={e => e.preventDefault()}>
                      <img
                        alt="..."
                        className="avatar"
                        src={require("assets/img/header.jpg")}
                      />
                      <h5 className="title">Travel</h5>
                    </a>
                    <p className="description">Ski Resort</p>
                  </div>
                  <div className="card-description">
                    {/* Description */}
                  </div>
                </CardBody>
                <CardFooter>
                  <div className="button-container">
                    <Button className="btn-icon btn-round" color="facebook">
                      <i className="fab fa-facebook" />
                    </Button>
                    <Button className="btn-icon btn-round" color="twitter">
                      <i className="fab fa-twitter" />
                    </Button>
                    <Button className="btn-icon btn-round" color="google">
                      <i className="fab fa-google-plus" />
                    </Button>
                  </div>
                </CardFooter>
              </Card>
            </Col>
            <Col md="6">
              <Card>
                <CardHeader>
                  <h5 className="title">Edit Device</h5>
                </CardHeader>
                <CardBody>
                  <Form onSubmit={this.handleSubmit}>
                    <Row>
                      <Col className="pr-md-1" md="6">
                        <FormGroup>
                          <label>Email</label>
                          <Input 
                            type="email" 
                            name="email" 
                            onChange={this.handleChange}
                          />
                        </FormGroup>
                        <FormGroup>
                          <label>Field (Generic)</label>
                          <Input type="" name="" />
                        </FormGroup>
                        <FormGroup>
                          <label>Field (Generic)</label>
                          <Input type="" name="" />
                        </FormGroup>
                        <FormGroup>
                          <label>Field (Generic)</label>
                          <Input type="" name="" />
                        </FormGroup>
                        <Button className="btn-fill" color="primary" type="submit">Save</Button>
                      </Col>
                    </Row>
                  </Form>
                </CardBody>
              </Card>
            </Col>
          </Row>
          <Row>
            <Col md="6">
              <Card className="card-user" style={{height: 94 + '%'}}>
                <CardBody>
                  <CardText />
                  <div className="author">
                    <div className="block block-one" />
                    <div className="block block-two" />
                    <div className="block block-three" />
                    <div className="block block-four" />
                    <a href="#pablo" onClick={e => e.preventDefault()}>
                      <img
                        alt="..."
                        className="avatar"
                        src={require("assets/img/bg5.jpg")}
                      />
                      <h5 className="title">Transport</h5>
                    </a>
                    <p className="description">Highway Billboard</p>
                  </div>
                  <div className="card-description">
                    {/* Description */}
                  </div>
                </CardBody>
                <CardFooter>
                  <div className="button-container">
                    <Button className="btn-icon btn-round" color="facebook">
                      <i className="fab fa-facebook" />
                    </Button>
                    <Button className="btn-icon btn-round" color="twitter">
                      <i className="fab fa-twitter" />
                    </Button>
                    <Button className="btn-icon btn-round" color="google">
                      <i className="fab fa-google-plus" />
                    </Button>
                  </div>
                </CardFooter>
              </Card>
            </Col>
            <Col md="6">
              <Card>
                <CardHeader>
                  <h5 className="title">Edit Placement</h5>
                </CardHeader>
                <CardBody>
                  <Form>
                    <Row>
                      <Col className="pr-md-1" md="6">
                        <FormGroup>
                          <label>Company (Disabled)</label>
                          <Input
                            defaultValue="Creative Code Inc."
                            disabled
                            placeholder="Company"
                            type="text"
                          />
                        </FormGroup>
                        <FormGroup>
                          <label>Field (Generic)</label>
                          <Input type="" name="" />
                        </FormGroup>
                        <FormGroup>
                          <label>Field (Generic)</label>
                          <Input type="" name="" />
                        </FormGroup>
                        <FormGroup>
                          <label>Field (Generic)</label>
                          <Input type="" name="" />
                        </FormGroup>
                      </Col>
                    </Row>
                  </Form>
                </CardBody>
                <CardFooter>
                  <Button className="btn-fill" color="primary" type="submit">
                    Save
                  </Button>
                </CardFooter>
              </Card>
            </Col>
          </Row>
          <Row>
            <Col md="6">
              <Card className="card-user" style={{height: 94 + '%'}}>
                <CardBody>
                  <CardText />
                  <div className="author">
                    <div className="block block-one" />
                    <div className="block block-two" />
                    <div className="block block-three" />
                    <div className="block block-four" />
                    <a href="#pablo" onClick={e => e.preventDefault()}>
                      <img
                        alt="..."
                        className="avatar"
                        src={require("assets/img/emilyz.jpg")}
                      />
                      <h5 className="title">Fashion</h5>
                    </a>
                    <p className="description">XBrand</p>
                  </div>
                  <div className="card-description">
                    {/* Description */}
                  </div>
                </CardBody>
                <CardFooter>
                  <div className="button-container">
                    <Button className="btn-icon btn-round" color="facebook">
                      <i className="fab fa-facebook" />
                    </Button>
                    <Button className="btn-icon btn-round" color="twitter">
                      <i className="fab fa-twitter" />
                    </Button>
                    <Button className="btn-icon btn-round" color="google">
                      <i className="fab fa-google-plus" />
                    </Button>
                  </div>
                </CardFooter>
              </Card>
            </Col>
            <Col md="6">
              <Card>
                <CardHeader>
                  <h5 className="title">Edit Creative</h5>
                </CardHeader>
                <CardBody>
                  <Form>
                    <Row>
                      <Col className="pr-md-1" md="6">
                        <FormGroup>
                          <label>Company (disabled)</label>
                          <Input
                            defaultValue="Creative Code Inc."
                            disabled
                            placeholder="Company"
                            type="text"
                          />
                        </FormGroup>
                        <FormGroup>
                          <label>Field (Generic)</label>
                          <Input type="" name="" />
                        </FormGroup>
                        <FormGroup>
                          <label>Field (Generic)</label>
                          <Input type="" name="" />
                        </FormGroup>
                        <FormGroup>
                          <label>Field (Generic)</label>
                          <Input type="" name="" />
                        </FormGroup>
                      </Col>
                    </Row>
                  </Form>
                </CardBody>
                <CardFooter>
                  <Button className="btn-fill" color="primary" type="submit">
                    Save
                  </Button>
                </CardFooter>
              </Card>
            </Col>
          </Row>
        </div>
      </>
    );
  }
}

export default UserProfile;
