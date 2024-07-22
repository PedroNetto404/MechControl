'use client';

import { useRouter } from "next/navigation";

//#TODO: Fix
const Page: React.FC = () => {
  const router = useRouter();
  router.replace("/pages/dashboard");

  return <></>
}

export default Page;