'use client'

import {
  ThemeProvider,
  CssBaseline,
} from "@mui/material";
import React from "react";
import { baselightTheme } from "@/utils/theme/DefaultColors";

export default function PageLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html lang="pt">
      <body>
        <ThemeProvider theme={baselightTheme}>
          <CssBaseline />
          {children}
        </ThemeProvider>
      </body>
    </html>
  );
}
