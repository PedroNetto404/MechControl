"use client";

import { Customer } from "@/types/customer";
import { CustomersTable } from "@/lib/components/pages/customer/customers-table";
import React, { useEffect, useMemo, useState } from "react";
import PageContainer from "@/lib/components/shared/PageContainer";
import { HttpResource } from "@/services/http-resource";
import { GetCustomersQuery } from "@/types/get-customers-query";
import {
  Box,
  Button,
  Card,
  CardContent,
  CardHeader,
  IconButton,
  Stack,
  Typography,
} from "@mui/material";
import { CustomersTableFilter } from "@/lib/components/pages/customer/customers-table-filter";
import { CustomerType } from "@/types/enums/customer-type";
import Loading from "@/app/loading";
import { useRouter } from "next/navigation";
import {
  Download as ExportIcon,
  Add as PlusIcon,
  Person as CustomerIcon,
} from "@mui/icons-material";

const Page: React.FC = () => {
  const [customers, setCustomers] = useState<Customer[]>([]);
  const [totalCount, setTotalCount] = useState<number>(0);
  const [loading, setLoading] = useState(true);
  const [currentFetchNumber, setCurrentFetchNumber] = useState(10);
  const [currentOffset, setCurrentOffset] = useState(0);
  const [searchText, setSearchText] = useState("");
  const [selectedCustomerTypes, setSelectedCustomerTypes] = useState<
    CustomerType[]
  >([CustomerType.individual, CustomerType.corporate]);
  const [filterExpanded, setFilterExpanded] = useState(true);
  const router = useRouter();

  const customerResource = useMemo(
    () => new HttpResource<Customer>("customers"),
    []
  );

  const onSelectCustomerType = (
    customerType: CustomerType,
    selected: boolean
  ) => {
    if (selected && !selectedCustomerTypes.includes(customerType)) {
      setSelectedCustomerTypes([...selectedCustomerTypes, customerType]);
      return;
    }

    setSelectedCustomerTypes(
      selectedCustomerTypes.filter((type) => type !== customerType)
    );
  };

  const fetchData = async () => {
    const response = await customerResource.getAll(
      new GetCustomersQuery(currentFetchNumber, currentOffset)
    );

    setCustomers(response.data);
    setTotalCount(response.total);
    setLoading(false);
  };

  useEffect(() => {
    fetchData();
  }, [currentFetchNumber, currentOffset]);

  const customersToShow = customers.filter((customer) => {
    if (!selectedCustomerTypes.includes(customer.type)) return false;

    const cleanSearchText = searchText.trim();
    if (cleanSearchText.length === 0) return true;

    return (
      customer.name.includes(cleanSearchText) ||
      customer.phone.includes(cleanSearchText) ||
      customer.document.includes(cleanSearchText)
    );
  });

  const onCustomerClick: (customerId: string) => void = (customerId) => {
    router.push(`/pages/customers/${customerId}`);
  };

  return (
    <PageContainer title="Clientes" description="Lista de clientes">
      {loading ? (
        <Loading />
      ) : (
        <Stack direction="column">
          <Stack direction="row" justifyContent="space-between"
            sx={{
              paddingBottom: '10px'
            }}
          >
            <Typography variant="h3">Clientes</Typography>
            <Button variant="contained">
              <PlusIcon /> Cadastrar cliente
            </Button>
          </Stack>
          <Card>
            <CardContent>
              <Stack>
                <CustomersTableFilter
                  onSearchTextChange={(searchText) => setSearchText(searchText)}
                  onCustomerTypeChange={onSelectCustomerType}
                />
                <CustomersTable
                  customers={customersToShow}
                  totalCount={totalCount}
                  onPaginationChange={(page, pageSize) => {
                    setCurrentFetchNumber(pageSize);
                    setCurrentOffset(page * pageSize - 1);
                  }}
                  onCustomerClick={onCustomerClick}
                />
              </Stack>
            </CardContent>
          </Card>
        </Stack>
      )}
    </PageContainer>
  );
};

export default Page;
