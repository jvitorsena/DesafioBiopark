import { API_URL } from "../api";

import axios from 'axios';
export interface ITodosEdificios {
    id: number;
    nome: string;
    locadora: string;
    createdAt: string;
    updatedAt: string;
    isActive: boolean;
}

export const TodosEdificios = fetch(`${API_URL}/edificios/todos`).then(
    (response) => response.json()
);

const headers = { 'headers': { 'Content-Type': 'application/json' } };
const api = axios.create({ baseURL: API_URL })

export const NovoEdificio = async (nome: string, locadora: string) => {
    await api.post("/edificios/novo", { nome: nome, locadora: locadora }, headers)
}

export const EditarEdificio = async (nome: string, locadora: string, id: number) => {
    await api.put(`${API_URL}/edificios/${id}`, { nome: nome, locadora: locadora }, headers)
}

export const ExcluirEdificio = async (id: number) => {
    const del = await api.post(`${API_URL}/edificios/${id}/desativar`, { data: {} }, headers);
}

export const EdificiosCabecalho: Array<string> = [
    "id",
    "Nome",
    "Locadora",
    "Data criação",
    "Data atualização",
    "Situação",
    "Ação",
];
