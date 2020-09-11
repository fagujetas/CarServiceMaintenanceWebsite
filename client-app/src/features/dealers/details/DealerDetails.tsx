import React from 'react';
import { Card, Image, Icon, Button } from 'semantic-ui-react';
import { IDealerInfo } from '../../../app/models/dealerInfo';

interface IProps {
    dealerinfos: IDealerInfo[]
}

export const DealerDetails: React.FC<IProps> = ({ dealerinfos }) => {
    return (
        <Card fluid>
            <Image src='/assets/placeholder.png' wrapped ui={false} />
            <Card.Content>
                <Card.Header>Dealer Name</Card.Header>
                <Card.Meta>
                    <span>Address</span>
                </Card.Meta>
                <Card.Meta>
                    <span>PostCode City</span>
                </Card.Meta>
                <Card.Description>
                    Contact Person
                </Card.Description>
                <Card.Description>
                    Contact Number
                </Card.Description>
            </Card.Content>
            <Card.Content extra>
                <Button.Group widths={2}>
                    <Button basic color='green' content='Set Appointment'/>
                    <Button basic color='grey' content='Cancel'/>
                </Button.Group>
            </Card.Content>
        </Card>
    )
}
