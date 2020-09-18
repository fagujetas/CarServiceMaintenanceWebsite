import React from 'react';
import { Card, Image, Button } from 'semantic-ui-react';
import { IDealerInfo } from '../../../app/models/dealerInfo';

interface IProps {
    dealer: IDealerInfo;
}

export const DealerDetails: React.FC<IProps> = ({ dealer }) => {
    return (
        <Card fluid>
            <Image src='/assets/placeholder.png' wrapped ui={false} />
            <Card.Content>
                <Card.Header>{dealer.name}</Card.Header>
                <Card.Meta>
                    <span>{dealer.address1}</span>
                </Card.Meta>
                <Card.Meta>
                    <span>{dealer.postCode} {dealer.city}</span>
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
                    <Button basic color='green' content='Set Appointment' />
                    <Button basic color='grey' content='Cancel' />
                </Button.Group>
            </Card.Content>
        </Card>
    )
}
