import { Card, CardHeader, Radio, RadioGroup, Stack, TextField } from "@mui/material";
import { CustomerType } from "@/types/enums/customer-type";
import {
  Accordion,
  AccordionSummary,
  AccordionDetails,
  Typography,
  Paper,
} from "@mui/material";

import ExpandMoreIcon from "@mui/icons-material/ExpandMore";
import { Label } from "@mui/icons-material";
type CustomersTableFilterProps = {
  onSearchTextChange: (searchText: string) => void;
  onSortChange: (sort: string) => void;
  onOrderChange: (order: string) => void;
  onFetchChange: (fetch: number) => void;
  onOffsetChange: (offset: number) => void;
  onCustomerTypeChange: (customerType: CustomerType, selected: boolean) => void;
};

export const CustomersTableFilter = (props: CustomersTableFilterProps) => {
  return (
    <Card>
      <CardHeader title="Filtrar" />
      <Accordion>
        <AccordionSummary expandIcon={<ExpandMoreIcon />}>
          <Typography>Search</Typography>
        </AccordionSummary>
        <AccordionDetails>
          <TextField
            label="Search"
            onChange={(e) => props.onSearchTextChange(e.target.value)}
          />
        </AccordionDetails>
      </Accordion>
      <Accordion>
        <AccordionSummary expandIcon={<ExpandMoreIcon />}>
          <Typography>Sort</Typography>
        </AccordionSummary>
        <AccordionDetails>
          <TextField
            label="Sort"
            onChange={(e) => props.onSortChange(e.target.value)}
          />
        </AccordionDetails>
      </Accordion>
      <Accordion>
        <AccordionSummary expandIcon={<ExpandMoreIcon />}>
          <Typography>Order</Typography>
        </AccordionSummary>
        <AccordionDetails>
          <TextField
            label="Order"
            onChange={(e) => props.onOrderChange(e.target.value)}
          />
        </AccordionDetails>
      </Accordion>
      <Accordion>
        <AccordionSummary expandIcon={<ExpandMoreIcon />}>
          <Typography>Fetch</Typography>
        </AccordionSummary>
        <AccordionDetails>
          <TextField
            label="Fetch"
            onChange={(e) => props.onFetchChange(Number(e.target.value))}
          />
        </AccordionDetails>
      </Accordion>
      <Accordion>
        <AccordionSummary expandIcon={<ExpandMoreIcon />}>
          <Typography>Offset</Typography>
        </AccordionSummary>
        <AccordionDetails>
          <TextField
            label="Offset"
            onChange={(e) => props.onOffsetChange(Number(e.target.value))}
          />
        </AccordionDetails>
      </Accordion>
      <Accordion>
        <AccordionSummary expandIcon={<ExpandMoreIcon />}>
          <Typography>Customer Type</Typography>
        </AccordionSummary>
        <AccordionDetails>
          <Stack spacing={2} direction="row">        
            <Radio
                value={CustomerType.individual}
                onChange={(e) =>
                    props.onCustomerTypeChange(
                    CustomerType.individual,
                    e.target.checked
                    )
                }
            />
              <Label>
                Pessoa Físisca
            </Label>
          </Stack>
        </AccordionDetails>
      </Accordion>
    </Card>
  );
};
