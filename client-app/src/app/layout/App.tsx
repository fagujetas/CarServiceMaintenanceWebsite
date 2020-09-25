import React, { useState, useEffect, Fragment } from 'react';
import { Container } from 'semantic-ui-react';
import { IDealerInfo } from '../models/dealerInfo';
import { NavBar } from '../../features/nav/NavBar';
import { DealersDashboard } from '../../features/dealers/dashboard/DealersDashboard';
import { ICityInfo } from '../models/cityInfo';
import { IAppointmentInfo } from '../models/appointmentInfo';
import apiAgent from '../api/apiAgent';
import { LoadingComponent } from './LoadingComponent';

const App = () => {

  const [dealerinfos, setDealerinfos] = useState<IDealerInfo[]>([]);
  const [cityinfos, setCityInfos] = useState<ICityInfo[]>([]);
  const [selectedDealer, setSelectedDealer] = useState<IDealerInfo | null>(null);

  //for showing/hiding appointment
  const [appointmentMode, setAppointmentMode] = useState(false);
  const [appointment, setAppointment] = useState<IAppointmentInfo | null>(null);

  //for loading component
  const [loading, setLoading] = useState(true);
  const [submitting, setSubmitting] = useState(false);

  const handleSelectedDealer = (id: string) => {
    setSelectedDealer(dealerinfos.filter(d => d.id === id)[0]);
    setAppointmentMode(false);
  };

  const handleCreateAppointment = (appointment: IAppointmentInfo) => {
    setSubmitting(true);
    apiAgent.Appointments.create(appointment).then(() => {
      console.log(`saving new appointment to database: ${appointment}`);
      setAppointment(appointment);
    }).then(() => setSubmitting(false));
    // setAppointment(appointment);
  };

  useEffect(() => {
    apiAgent.Dealers.list()
      .then(response => {
        let dealers: IDealerInfo[] = [];
        response.forEach((dealer) => {
          dealers.push(dealer);
        });
        setDealerinfos(dealers)
      }).then(() => setLoading(false));
  }, []);

  useEffect(() => {
    apiAgent.Dealers.getAllCities()
      .then(response => {
        let cities: ICityInfo[] = [];
        response.forEach((city) => {
          cities.push(city);
        });
        setCityInfos(cities)
      }).then(() => setLoading(false));
  }, []);

  if (loading) {
    return <LoadingComponent content='Loading...' />
  }

  return (
    <Fragment>
      <NavBar cityinfos={cityinfos} />
      <Container style={{ marginTop: '6em' }}>
        <DealersDashboard 
            dealerinfos={dealerinfos} 
            cityinfos={cityinfos}
            selectDealer={handleSelectedDealer} 
            selectedDealer={selectedDealer}
            appointmentMode={appointmentMode}
            setAppointmentMode={setAppointmentMode}
            createAppointment={handleCreateAppointment}
            appointment={appointment}
            submitting={submitting}
        />
      </Container>
    </Fragment>
  );
}

export default App;