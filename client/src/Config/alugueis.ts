import { API_URL } from "../api";
import axios from 'axios';

export interface ITodosAlugueis {
    id: number;
    valorAluguelMen: number;
    locatarioId: number;
    apartamentoId: number;
    locatario: string;
    apartamento: number;
    createdAt: string;
    updatedAt: string;
    isActive: boolean;
}

export const TodosAlugueis = fetch(`${API_URL}/contratos/todos`).then(
    (response) => response.json()
);

const headers = { 'headers': { 'Content-Type': 'application/json' } };
const api = axios.create({ baseURL: API_URL });

export const NovoAluguel = async (valorAluguelMen: number, locatarioId: number, apartamentoId: number) => {
    await api.post("/contratos/novo", { valorAluguelMen: valorAluguelMen, locatarioId: locatarioId, apartamentoId: apartamentoId }, headers);
    await api.post(`/apartamentos/${apartamentoId}/alugar`, { data: {} }, headers);
}

export const EditarAluguel = async (valorAluguelMen: number, locatarioId: number, apartamentoId: number, id: number) => {
    await api.put(`${API_URL}/contratos/${id}`, { valorAluguelMen: valorAluguelMen, locatarioId: locatarioId, apartamentoId: apartamentoId }, headers)
}

export const ExcluirAluguel = async (id: number, apartamentoId: number) => {
    await api.post(`${API_URL}/contratos/${id}/desativar`, { data: {} }, headers);
    await api.post(`${API_URL}/apartamentos/${apartamentoId}/liberar`, { data: {} }, headers);
}

export const AlugueisCabecalho: Array<string> = [
    "id",
    "Valor",
    "Locatario",
    "Apartamento",
    "Data criação",
    "Data atualização",
    "Situação",
    "Ação",
];