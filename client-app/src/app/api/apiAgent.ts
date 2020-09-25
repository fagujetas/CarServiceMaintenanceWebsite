import axios, { AxiosResponse } from 'axios';
import { IAppointmentInfo } from '../models/appointmentInfo';
import { ICityInfo } from '../models/cityInfo';
import { IDealerInfo } from '../models/dealerInfo';

axios.defaults.baseURL = 'http://localhost:5000/api';

const responseBody = (response: AxiosResponse) => response.data;

const sleep = (ms: number) => (response: AxiosResponse) =>
new Promise<AxiosResponse>(resolve => setTimeout(() => resolve(response), ms));

const requests = {
    get: (url: string) => axios.get(url).then(sleep(1000)).then(responseBody),
    post: (url: string, body: {}) => axios.post(url, body).then(sleep(1000)).then(responseBody),
    put: (url: string, body: {}) => axios.put(url, body).then(sleep(1000)).then(responseBody),
    del: (url: string) => axios.delete(url).then(sleep(1000)).then(responseBody)
}

const Dealers = {
    list: (): Promise<IDealerInfo[]> => requests.get('/dealerinfos'),
    details: (id: string) => requests.get(`/dealerinfos/${id}`),
    create: (dealer: IDealerInfo) => requests.post('/dealerinfos/', dealer),
    update: (dealer: IDealerInfo) => requests.post(`/dealerinfos/${dealer.id}`, dealer),
    delete: (id: string) => requests.del(`/dealerinfos/${id}`),
    getAllCities: (): Promise<ICityInfo[]> => requests.get('/dealerinfos/searchallcities')
}

const Appointments = {
    list: () => requests.get('/appointmentinfos'),
    details: (id: string) => requests.get(`/appointmentinfos/${id}`),
    create: (appointment: IAppointmentInfo) => requests.post('/appointmentinfos/', appointment),
    update: (appointment: IAppointmentInfo) => requests.post(`/appointmentinfos/${appointment.id}`, appointment),
    delete: (id: string) => requests.del(`/appointmentinfos/${id}`)
}

export default {
    Dealers,
    Appointments
}