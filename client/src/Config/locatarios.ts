import { API_URL } from "../api";
import axios from 'axios';

export interface ITodosLocatarios {
    id: number;
    nome: string;
    dataNasc: string;
    createdAt: string;
    updatedAt: string;
    isActive: boolean;
}

export const TodosLocatarios = fetch(`${API_URL}/locatarios/todos`).then(
    (response) => response.json()
);

const headers = { 'headers': { 'Content-Type': 'application/json' } };
const api = axios.create({ baseURL: API_URL })

export const NovoLocatario = async (nome: string, dataNasc: string) => {
    await api.post("/locatarios/novo", { nome: nome, dataNasc: dataNasc }, headers);
}

export const EditarLocatario = async (nome: string, dataNasc: string, id: number) => {
    await api.put(`${API_URL}/locatarios/${id}`, { nome: nome, dataNasc: dataNasc }, headers)
}

export const ExcluirLocatario = async (id: number) => {
    const del = await api.post(`${API_URL}/locatarios/${id}/desativar`, { data: {} }, headers);
}

export const LocatariosCabecalho: Array<string> = [
    "id",
    "Nome Completo",
    "Data de nascimento",
    "Data criação",
    "Data atualização",
    "Situação",
    "Ação",
];