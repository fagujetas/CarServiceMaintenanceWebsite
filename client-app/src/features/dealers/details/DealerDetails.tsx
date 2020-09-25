import React from 'react';
import { Card, Image, Button } from 'semantic-ui-react';
import { IAppointmentInfo } from '../../../app/models/appointmentInfo';
import { IDealerInfo } from '../../../app/models/dealerInfo';

interface IProps {
    dealer: IDealerInfo;
    setAppointmentMode: (appointmentMode: boolean) => void;
    selectDealer: (id: string) => void;
    setAppointment: (appointment: IAppointmentInfo) => void;
}

export const DealerDetails: React.FC<IProps> = ({ dealer, setAppointmentMode, selectDealer, setAppointment }) => {


    const handleOpenCreateForm = () => {
        //setAppointment(null);
        setAppointmentMode(true);
    }

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
                    {/* <Button onClick={() => setAppointmentMode(true)} basic color='green' content='Set Appointment' /> */} 
                    <Button onClick={handleOpenCreateForm} basic color='green' content='Set Appointment' />
                    <Button onClick={() => selectDealer(null)} basic color='grey' content='Cancel' />
                </Button.Group>
            </Card.Content>
        </Card>
    )
}
