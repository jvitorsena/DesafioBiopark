import { API_URL } from "../api";

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

export const teste = API_URL;
