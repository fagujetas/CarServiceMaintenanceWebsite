import React, { FormEvent, useState } from 'react';
import { Button, Form, Item, Label, Segment } from 'semantic-ui-react';
import { IAppointmentInfo } from '../../app/models/appointmentInfo';
import { v4 as uuid } from 'uuid';

interface IProps {
    appointment: IAppointmentInfo;
    setAppointmentMode: (appointmentMode: boolean) => void;
    createAppointment: (appointment: IAppointmentInfo) => void;
    submitting: boolean;
}

const typeOptions = [
    { key: 0, text: 'Maintenance', value: 'Maintenance' },
    { key: 1, text: 'Repairs', value: 'Repairs' }
]

export const SetAppointmentForm: React.FC<IProps> = ({
    setAppointmentMode,
    appointment: initialFormState,
    createAppointment,
    submitting
}) => {

    const initializeForm = () => {
        if (initialFormState) {
            console.log('form is initialized!');
            return initialFormState;
        }
        else {
            console.log('form is not initialized!');
            return {
                id: '',
                firstName: '',
                lastName: '',
                address: '',
                contactNumber: '',
                email: '',
                carMake: '',
                carModel: '',
                carYear: '',
                isMaintenance: true,
                dateTimeOfAppointment: null,
            };
        }
    };

    const [appointment, setAppointment] = useState<IAppointmentInfo>(initializeForm);

    const handleSubmit = () => {
        console.log(`appointment upon submission: ${appointment}`);
        let newAppointment = {
            //...appointment,
            id: '',
            firstName: appointment.firstName,
            lastName: appointment.lastName,
            address: appointment.address,
            contactNumber: appointment.contactNumber,
            email: appointment.email,
            carMake: appointment.carMake,
            carModel: appointment.carModel,
            carYear: appointment.carYear,
            isMaintenance: appointment.isMaintenance,
            dateTimeOfAppointment: appointment.dateTimeOfAppointment
            // ...appointment,
            // id: uuid(),
        };

        console.log(`attempting to save new appointment: ${newAppointment}`);

        //setAppointment(newAppointment);
        createAppointment(newAppointment);
    };

    const handleInputChange = (
        event: FormEvent<HTMLInputElement>
    ) => {
        const { name, value } = event.currentTarget;
        setAppointment({ ...appointment, [name]: value });
    };

    return (
        <Segment clearing>
            <Item.Group divided>
                <Label as='a' horizontal>
                    <img src='/assets/fill_up_form_icon_2.png' alt='fillUpForm' style={{ marginRight: '10px' }} />
                    Please Fill up Form to Set Appointment
                </Label>
            </Item.Group>
            <Item.Group divided>
                <Form onSubmit={handleSubmit}>
                    <Form.Input
                        onChange={handleInputChange}
                        name='firstName'
                        placeholder='First Name'
                    />
                    <Form.Input
                        onChange={handleInputChange}
                        name='lastName'
                        placeholder='Last Name'
                    />
                    <Form.Input
                        onChange={handleInputChange}
                        name='address'
                        placeholder='Address'
                    />
                    <Form.Input
                        onChange={handleInputChange}
                        name='contactNumber'
                        placeholder='Contact Number'
                    />
                    <Form.Input
                        onChange={handleInputChange}
                        name='email'
                        placeholder='Email'
                    />
                    <Form.Input
                        onChange={handleInputChange}
                        name='carMake'
                        placeholder='Car Make'
                    />
                    <Form.Input
                        onChange={handleInputChange}
                        name='carModel'
                        placeholder='Car Model'
                    />
                    <Form.Input
                        onChange={handleInputChange}
                        name='carYear'
                        placeholder='Car Year'
                    />
                    <Form.Select
                        onChange={handleInputChange}
                        name='isMaintenance'
                        fluid
                        options={typeOptions}
                        placeholder='Type Of Appointment'
                    />
                    <Form.Input
                        onChange={handleInputChange}
                        name='dateTimeOfAppointment'
                        type='datetime-local'
                        placeholder='Date Of Appointment'
                    />
                    <Button.Group widths={2}>
                        <Button loading={submitting} basic color='green' content='Submit' type='submit' />
                        <Button onClick={() => setAppointmentMode(false)} basic color='grey' content='Cancel' />
                    </Button.Group>
                </Form>
            </Item.Group>
        </Segment>
    )
}
