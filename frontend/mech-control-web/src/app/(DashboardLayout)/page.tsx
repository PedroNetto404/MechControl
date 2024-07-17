'use client'
import { Grid, Box } from '@mui/material';
import PageContainer from '@/lib/components/shared/PageContainer';
import SalesOverview from '@/lib/components/pages/dashboard/SalesOverview';
import YearlyBreakup from '@/lib/components/pages/dashboard/YearlyBreakup';
import RecentTransactions from '@/lib/components/pages/dashboard/RecentTransactions';
import ProductPerformance from '@/lib/components/pages/dashboard/ProductPerformance';
import Blog from '@/lib/components/pages/dashboard/Blog';
import MonthlyEarnings from '@/lib/components/pages/dashboard/MonthlyEarnings';

const Dashboard = () => {
  return (
    <PageContainer title="Dashboard" description="this is Dashboard">
      <Box>
        <Grid container spacing={3}>
          <Grid item xs={12} lg={8}>
            <SalesOverview />
          </Grid>
          <Grid item xs={12} lg={4}>
            <Grid container spacing={3}>
              <Grid item xs={12}>
                <YearlyBreakup />
              </Grid>
              <Grid item xs={12}>
                <MonthlyEarnings />
              </Grid>
            </Grid>
          </Grid>
          <Grid item xs={12} lg={4}>
            <RecentTransactions />
          </Grid>
          <Grid item xs={12} lg={8}>
            <ProductPerformance />
          </Grid>
          <Grid item xs={12}>
            <Blog />
          </Grid>
        </Grid>
      </Box>
    </PageContainer>
  )
}

export default Dashboard;
