import { PaginatedQuery } from "./paginated-query";

export class GetCustomersQuery extends PaginatedQuery
{
    protected getAllowValues(): string[] {
        return ["id", "name", "email", "phone"];
    }
}