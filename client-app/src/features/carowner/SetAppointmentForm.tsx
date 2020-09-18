import React from 'react'
import { Form, Item, Label, Segment } from 'semantic-ui-react'

const typeOptions = [
    { key: 0, text: 'Maintenance', value: 'Maintenance' },
    { key: 1, text: 'Repairs', value: 'Repairs' }
]

export const SetAppointmentForm = () => {
    return (
        <Segment clearing>
            <Item.Group divided>
                <Label as='a' horizontal>
                    <img src='/assets/fill_up_form_icon_2.png' alt='fillUpForm' style={{ marginRight: '10px' }} />
                    Please Fill up Form to Register / Set Appointment
                </Label>
            </Item.Group>
            <Item.Group divided>
                <Form>
                    <Form.Input placeholder='Name' />
                    <Form.Input placeholder='Address' />
                    <Form.Input placeholder='Contact Number' />
                    <Form.Input placeholder='Email' />
                    <Form.Input placeholder='Car Make' />
                    <Form.Input placeholder='Car Model' />
                    <Form.Input placeholder='Car Year' />
                    <Form.Select
                        fluid
                        options={typeOptions}
                        placeholder='Type Of Appointment'
                    />
                    <Form.Input type='date' placeholder='Date Of Appointment' />
                </Form>
            </Item.Group>
        </Segment>
    )
}
