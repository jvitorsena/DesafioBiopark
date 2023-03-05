import { API_URL } from "../api";
import axios from 'axios';

export interface ITodosApartamentos {
    id: number;
    numero: number;
    andar: number;
    alugado: boolean;
    edificio: string;
    edificiosId: number;
    createdAt: string;
    updatedAt: string;
    isActive: boolean;
}

export const TodosApartamentos = fetch(`${API_URL}/apartamentos/todos`).then(
    (response) => response.json()
);

const headers = { 'headers': { 'Content-Type': 'application/json' } };
const api = axios.create({ baseURL: API_URL });

export const NovoApartamento = async (numero: number, andar: number, edificiosId: number) => {
    await api.post("/apartamentos/novo", { numero: numero, andar: andar, edificiosId: edificiosId }, headers)
}

export const EditarApartamento = async (numero: number, andar: number, edificiosId: number, id: number) => {
    await api.put(`${API_URL}/apartamentos/${id}`, { numero: numero, andar: andar, edificiosId: edificiosId }, headers)
}

export const ExcluirApartamento = async (id: number) => {
    await api.post(`${API_URL}/apartamentos/${id}/desativar`, { data: {} }, headers);
}

export const ApartamentosCabecalho: Array<string> = [
    "id",
    "Numero",
    "Andar",
    "Alugado",
    "Edificio",
    "Data criação",
    "Data atualização",
    "Situação",
    "Ação",
];