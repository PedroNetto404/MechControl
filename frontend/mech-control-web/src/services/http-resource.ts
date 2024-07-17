import axios, { AxiosInstance } from "axios";
import { Response, ListResponse } from "@/types/response";
import { PaginatedQuery } from "@/types/paginated-query";

const BASE_URL = "http://localhost:3000";

export class HttpResource<TResource> {
  private axiosInstance: AxiosInstance;
  private resourceName: string;

  public constructor(resourceName: string) {
    this.resourceName = resourceName;

    this.axiosInstance = axios.create({
      baseURL: BASE_URL,
      headers: {
        "Content-Type": "application/json",
      },
    });

    this.axiosInstance.interceptors.request.use((config) => {
      const token = localStorage.getItem(".Mech-Control-Token");

      if (token) {
        config.headers.Authorization = `Bearer ${token}`;
      }

      return config;
    });
  }

  public getById(id: string): Promise<Response<TResource>> {
    return this.axiosInstance.get(`/${this.resourceName}/${id}`);
  }

  public getAll(query: PaginatedQuery): Promise<ListResponse<TResource>> {
    return this.axiosInstance.get(`/${this.resourceName}`, {
      params: query,
    });
  }

  public create(data: TResource): Promise<TResource> {
    return this.axiosInstance.post(`/${this.resourceName}`, data);
  }

  public update(id: string, data: TResource): Promise<Response<TResource>> {
    return this.axiosInstance.put(`/${this.resourceName}/${id}`, data);
  }

  public delete(id: string): Promise<void> {
    return this.axiosInstance.delete(`/${this.resourceName}/${id}`);
  }
}
