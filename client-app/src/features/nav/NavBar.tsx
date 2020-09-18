import React from 'react';
import { Menu, Container, Button } from 'semantic-ui-react'
import { SearchDropdownCity } from '../search/SearchDropdownCity';
import { ICityInfo } from '../../app/models/cityInfo';

interface IProps {
    cityinfos: ICityInfo[]
}

export const NavBar: React.FC<IProps> = ({ cityinfos }) => {
    return (
        <Menu fixed='top' inverted>
            <Container>
                <Menu.Item header>
                    <img src="/assets/logo.png" alt="logo" style={{ marginRight: '10px' }} />
                Car Service Maintenance
            </Menu.Item>
                <Menu.Item name='Dealer' />
                {/* <Menu.Item>
                    <SearchDropdownCity cityinfos={cityinfos} />
                </Menu.Item> */}
                <Menu.Item>
                    <Button content="Set Appointment" />
                </Menu.Item>
            </Container>
        </Menu>
    )
}