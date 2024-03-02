import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import NewsSource from "../../models/NewsSource";
import NewsPiece from "../../models/NewsPiece";
import axios from "axios";
import { Box, Grid, Paper, Typography, styled } from "@mui/material";
import NavBar from "./navbar";

const ArticlePaper = styled(Paper)(({ theme }) => ({
    
    
    padding: theme.spacing(1),
    margin: 20,
    textOverflow:"elipsis", 
    ...theme.typography.body2,
    textAlign: 'center',
    display: "flex", 
    flexDirection:"column",
    justifyContent: "center",
    height:"85%",
    backgroundColor:"#faf6f5"
  }));
  
  

export default function FromSource() {
    let {id} = useParams(); 
    const [news, setNews] = useState<NewsPiece[]>(); 
    
    useEffect(() => {
        
        // Dev
        // axios.get<NewsPiece[]>('http://localhost:8004/api/News/GetNewsFromSource/' + id).then(response => {
        //     setNews(response.data)
        // })
        
        // Prod
        axios.get<NewsPiece[]>('/api/News/GetNewsFromSource/' + id).then(response => {
            setNews(response.data)
        })
    }, []);

    
    return (
        <div>
        <NavBar/>
    
        <Box>
        <Grid direction={"row"} container columns={{ xs: 12, md: 8, lg:8, xl:8}} rowGap={4}>
          
          {news?.map(x => (
          
              
              <Grid item xs={2} key={x.newsID} style = {{textOverflow: 'elipsis'}}>
                <ArticlePaper>
                  <Typography  component="a" href={`/detailed/${x.newsID}`} align= {"center"} sx={{ fontSize: 14 }} color="text.secondary" >
                    {x.title + "..."}
                  </Typography>
                </ArticlePaper>
              </Grid>
               
    
       
            
    
          ))}
     
          </Grid>
          </Box>
        </div>
        
    );

}

