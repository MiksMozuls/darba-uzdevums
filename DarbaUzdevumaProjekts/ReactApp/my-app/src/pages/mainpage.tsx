import React, { useEffect, useState } from 'react';
import axios from 'axios'; 
import logo from './logo.svg';
import NewsPiece from '../../models/NewsPiece';
import NewsSource from '../../models/NewsSource';
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import Typography from '@mui/material/Typography';
import Box from '@mui/material/Box';
import { AppBar, Grid, Link, Paper, Toolbar, styled } from '@mui/material'; 
import NavBar from './navbar';


const ArticlePaper = styled(Paper)(({ theme }) => ({
    width: 120,
    height: 120,
    padding: theme.spacing(2),
    margin: 20,
    ...theme.typography.body2,
    textAlign: 'center',
  }));
  
  

export default function MainPage() {
    const [news, setNews] = useState<NewsPiece[]>([]); 
    useEffect(() => {
      axios.get<NewsPiece[]>('http://localhost:8004/api/News/GetNews').then(response => {
        console.log(response)
        setNews(response.data)
      })
  });
  return (
    <div>
    <NavBar/>

    <Box sx={{ flexGrow: 1 }}>
    <Grid direction={'row'} container >
      
      {news.map(x => (
        <div>
          
          <Grid item xs = {12} spacing={2}>
                    
            
            <ArticlePaper>
              <Typography align= {"center"} sx={{ fontSize: 14 }} color="text.secondary">
                {x.title.substring(0,50) + "..."}
              </Typography>
            </ArticlePaper>
      
    
       
          </Grid>
           

        </div>
        

      ))}
 
      </Grid>
      </Box>
    </div>
    
  )
}

export {}