import React, { useEffect, useState } from 'react';
import axios from 'axios';  
import NewsSource from '../../models/NewsSource';
import Box from '@mui/material/Box';
import AppBar from '@mui/material/AppBar';
import Grid from '@mui/material/Grid';
import { Toolbar, Typography } from '@mui/material';


export default function NavBar(){
    const [newsources, setNewsSource] = useState<NewsSource[]>([]); 
    useEffect(() => {
        axios.get<NewsSource[]>('http://localhost:8004/api/News/Sources').then(response => {
            console.log(response)
            setNewsSource(response.data)
        }); 
    
    }, []);
  
    return (
        <Box sx={{ flexGrow: 1 }}>
        <AppBar style={{ background: '#2E3B55' }} position="static">
          <Toolbar>
          <Grid container spacing={2}>
            {newsources.map((x) => (
            <Grid item>
                <Typography style={{ color: '#ffffff'}} component="a" href={`/fromSource/${x.sourceID}`} variant="h6">
                {x.sourceName}
                </Typography> 
            </Grid>
            ))} 
          </Grid>  
          </Toolbar>
        </AppBar>
      </Box>


    ); 
}