import {
  IconAperture,
  IconCopy,
  IconLayoutDashboard,
  IconLogin,
  IconMoodHappy,
  IconTypography,
  IconUserPlus,
  IconCar,
} from "@tabler/icons-react";

import { uniqueId } from "lodash";

const ManagementMenuitems = [
  {
    navlabel: true,
    subheader: "Gerencial",
  },
  {
    id: uniqueId(),
    title: 'Clientes',
    icon: IconLayoutDashboard,
    href: '/management/customers',
  },
  {
    id: uniqueId(),
    title: 'Veículos',
    icon: IconCar,
    href: '/management/vehicles'
  }
];

const Menuitems = [
  ...ManagementMenuitems,
];

export default Menuitems;
