import {
  IconLayoutDashboard,
  IconCar,
} from "@tabler/icons-react";
import {
  Person as IconPerson,
} from "@mui/icons-material";

import { uniqueId } from "lodash";

const ManagementMenuitems = [
  {
    id: uniqueId(),
    title: 'Relatórios',
    icon: IconLayoutDashboard,
    href: '/pages/dashboard',
  },
  {
    navlabel: true,
    subheader: "Gerencial",
  },
  {
    id: uniqueId(),
    title: 'Clientes',
    icon: IconPerson,
    href: '/pages/customers',
  },
  {
    id: uniqueId(),
    title: 'Veículos',
    icon: IconCar,
    href: '/pages/vehicles'
  }
];

const Menuitems = [
  ...ManagementMenuitems,
];

export default Menuitems;
