"use client";

import { Customer } from "@/types/customer";
import { CustomersTable } from "@/lib/components/pages/customer/customers-table";
import React from "react";
import PageContainer from "@/lib/components/shared/PageContainer";
import { HttpResource } from "@/services/http-resource";
import { GetCustomersQuery } from "@/types/get-customers-query";
import { Stack } from "@mui/material";
import { CustomersTableFilter } from "@/lib/components/pages/customer/customers-table-filter";
import { CustomerType } from "@/types/enums/customer-type";

const customerResource = new HttpResource<Customer>("customers");

const Page: React.FC = () => {
  const [customers, setCustomers] = React.useState<Customer[]>([]);
  const [totalCount, setTotalCount] = React.useState<number>(0);
  const [loading, setLoading] = React.useState(true);
  const [currentFetchNumber, setCurrentFetchNumber] = React.useState(10);
  const [currentOffset, setCurrentOffset] = React.useState(0);
  const [currentSortOrder, setCurrentSortOrder] = React.useState("asc");
  const [currentSortBy, setCurrentSortBy] = React.useState("name");
  const [selectedCustomerTypes, setSelectedCustomerTypes] = React.useState<CustomerType[]>([]);

  const onSelectCustomerType = (customerType: CustomerType, selected: boolean) => {
    if(selected && !selectedCustomerTypes.includes(customerType)) {
      setSelectedCustomerTypes([...selectedCustomerTypes, customerType]);
      return;
    }

    setSelectedCustomerTypes(selectedCustomerTypes.filter((type) => type !== customerType));
  }

  const fetchData = async () => {
    const response = await customerResource.getAll(
      new GetCustomersQuery(
        currentFetchNumber,
        currentOffset,
        currentSortOrder,
        currentSortBy
      )
    );

    setCustomers(response.data);
    setTotalCount(response.total);
    setLoading(false);
  };

  React.useEffect(() => {
    fetchData();
  }, [currentFetchNumber, currentOffset, currentSortOrder, currentSortBy]);

  return (
    <PageContainer title="Clientes" description="Lista de clientes">
      {loading ? (
        <div>Loading...</div>
      ) : (
        <Stack>
          <CustomersTableFilter 
              onFetchChange={(fetch) => setCurrentFetchNumber(fetch)}
              onOffsetChange={(offset) => setCurrentOffset(offset)}
              onOrderChange={(order) => setCurrentSortOrder(order)}
              onSearchTextChange={(searchText) => console.log(searchText)}
              onSortChange={(sort) => setCurrentSortBy(sort)} 
              onCustomerTypeChange={onSelectCustomerType}
          />
          <CustomersTable
            customers={customers}
            totalCount={totalCount}
          />
        </Stack>
      )}
    </PageContainer>
  );
};

export default Page;
