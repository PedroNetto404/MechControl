"use client";

import Header from "@/lib/layout/header/Header";
import Sidebar from "@/lib/layout/sidebar/Sidebar";
import { Box, Container, styled } from "@mui/material";
import { useMemo, useState } from "react";

const ResourcesLayout: React.FC<{ children: React.ReactNode }> = ({
  children,
}) => {
  const [isSidebarOpen, setIsSidebarOpen] = useState(true);

  const MainWrapper = styled("div")(() => ({
    display: "flex",
    minHeight: "100vh",
    width: "100%",
  }));

  const PageWrapper = useMemo(
    () =>
      styled("div")(() => ({
        display: "flex",
        flexGrow: 1,
        paddingBottom: "60px",
        flexDirection: "column",
        width: `calc(100vh - ${isSidebarOpen ? 270 : 0}px)`,
        zIndex: 1,
        backgroundColor: "transparent",
      })),
    [isSidebarOpen]
  );

  return (
    <>
      <MainWrapper className="mainwrapper">
        <Sidebar
          isSidebarOpen={isSidebarOpen}
          closeSidebar={() => setIsSidebarOpen(false)}
        />
        <PageWrapper className="page-wrapper">
          <Header
            isSidebarOpen={isSidebarOpen}
            openSidebar={() => setIsSidebarOpen(true)}
          />
          <Box
            px={10}
            sx={{
              minHeight: "calc(100vh - 170px)",
              paddingTop: "20px",
            }}
          >
            {children}
          </Box>
        </PageWrapper>
      </MainWrapper>
    </>
  );
};

export default ResourcesLayout;
