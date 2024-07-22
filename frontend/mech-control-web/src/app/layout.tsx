import React from "react";
import { CustomThemeProvider } from "@/lib/contexts/custom-theme-context";

const PageLayout = ({ children }: { children: React.ReactNode }) => {
  return (
    <html lang="pt">
      <body>
        <CustomThemeProvider>{children}</CustomThemeProvider>
      </body>
    </html>
  );
};

export default PageLayout;
