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
