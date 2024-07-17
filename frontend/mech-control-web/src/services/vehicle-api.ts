import { PaginatedQuery } from "@/types/paginated-query";
import { httpClient } from "./http-resource";
import { Vehicle } from "@/types/vehicle";

interface getAllParams extends PaginatedQuery
{
}

const getAll: (params: getAllParams) => Promise<Vehicle[]> = async (params) => {
    const { data } = await httpClient.get('/vehicles', { params });
    return data;
}

const getById: (id: string) => Promise<Vehicle> = async (id) => {
    const { data } = await httpClient.get(`/vehicles/${id}`);
    return data;
}

const create: (vehicle: Vehicle) => Promise<Vehicle> = async (vehicle) => {
    const { data } = await httpClient.post('/vehicles', vehicle);
    return data;
}