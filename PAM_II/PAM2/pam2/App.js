import { View, TextInput, Text, StyleSheet } from 'react-native';


export default function App() {
  return (
    <View style={css.container}>
        <View style={css.box} > </View>

        <View style={css.formulario} >
            <Text> Login </Text>
            <TextInput style={css.input} />
         </View>

        <View style={css.formulario} >
            <Text> Senha </Text>
            <TextInput style={css.input} />
         </View>

        <View style={css.formulario} > </View>
    </View>  
  );
}

const css = StyleSheet.create({
    box:{
      height:200,
      width:200,
      backgroundColor:'#666',
      borderColor:'#999',
      borderWidth:5,
      margin:20,
    },
    formulario:{
      height:50,
      width:200,
      marginTop:5,
      justifyContent:'center',//alinhamento vertical
      alignItems: 'center', //alinhamento horizontal
      
    },
    input:{
      backgroundColor:'#fff',
      borderWidth:1,
      borderColor:'#000',
      width:190,
      height:70,
      borderRadius: 50,
    },
    container:{
      backgroundColor:'#ccc',
      flex:1,
      justifyContent:'center',//alinhamento vertical
      alignItems: 'center' //alinhamento horizontal
    }
});
