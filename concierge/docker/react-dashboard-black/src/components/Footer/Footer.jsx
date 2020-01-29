//Black Dashboard React v1.0.0
//Product Page: https://www.creative-tim.com/product/black-dashboard-react
// Copyright 2019 Creative Tim (https://www.creative-tim.com)
//Licensed under MIT (https://github.com/creativetimofficial/black-dashboard-react/blob/master/LICENSE.md)
//Coded by Creative Tim
//The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

//----------------------------
//Modified by SR Runblade 2020
//----------------------------

/*eslint-disable*/
import React from "react";
// used for making the prop types of this component
import PropTypes from "prop-types";

// reactstrap components
import { Container, Row, Nav, NavItem, NavLink } from "reactstrap";

class Footer extends React.Component {
  render() {
    return (
      <footer className="footer">
        <Container fluid>
          <Nav>
            <NavItem>
              <NavLink href="javascript:void(0)">Footer Item 1</NavLink>
            </NavItem>
            <NavItem>
              <NavLink href="javascript:void(0)">Footer Item 2</NavLink>
            </NavItem>
            <NavItem>
              <NavLink href="javascript:void(0)">Footer Item 3</NavLink>
            </NavItem>
          </Nav>
          <div className="copyright">
            By Creative Tim (Modified SR Runblade 2020)
          </div>
        </Container>
      </footer>
    );
  }
}

export default Footer;
