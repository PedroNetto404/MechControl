export interface HateoasLink{
    href: string;
    rel: string;
}

export interface Response<T>
{
    data: T[];
    links: HateoasLink[];
}

export interface ListResponse<T> extends Response<T>
{
    total: number;
    offset: number;
    fetch: number;
    sort: string;
    order: string;
}