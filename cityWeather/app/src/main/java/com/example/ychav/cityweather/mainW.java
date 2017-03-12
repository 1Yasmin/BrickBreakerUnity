package com.example.ychav.cityweather;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;


//faecd119485e934496d90574a6e29116 APPIKEY

public class mainW extends AppCompatActivity implements View.OnClickListener{


    String pais = "";
    String ciudad = "";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main_w);

        Button buscar = (Button) findViewById(R.id.buttonBuscar);

        buscar.setOnClickListener(new Button.OnClickListener()){
            public void onClick(View v){

            }
        }
        EditText nombrePais= (EditText) findViewById(R.id.editTextPais);
        pais = nombrePais.getText().toString();

        EditText nombreCiudad = (EditText) findViewById(R.id.editTextCiudad);
        ciudad = nombreCiudad.getText().toString();


    }
}
