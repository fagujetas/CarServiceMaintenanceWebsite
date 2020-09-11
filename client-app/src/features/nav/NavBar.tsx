import React from 'react';
import { Menu, Container, Button } from 'semantic-ui-react'

const NavBar = () => {
    return (
        <Menu fixed='top' inverted>
            <Container>
                <Menu.Item header>
                    <img src="/assets/logo.png" alt="logo" style={{marginRight: '10px'}} />
                    Car Service Maintenance
                </Menu.Item>
                <Menu.Item name='Dealer' />
                <Menu.Item>
                    <Button content="Set Appointment" />
                </Menu.Item>
            </Container>
        </Menu>
    );
};

export default NavBar;