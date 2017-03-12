package com.example.ychav.weather;

import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import org.apache.http.client.methods.*;
import org.json.JSONException;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.client.HttpClient;

import org.apache.http.HttpResponse;
//import org.apache.http.client.HttpEntity;
import org.apache.http.HttpEntity;
import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import org.apache.http.StatusLine;
import org.json.JSONObject;
import org.json.JSONArray;
import java.text.NumberFormat;
import com.google.android.gms.appindexing.Action;
import com.google.android.gms.appindexing.AppIndex;
import com.google.android.gms.appindexing.Thing;
import com.google.android.gms.common.api.GoogleApiClient;
import com.google.android.gms.common.server.converter.StringToIntConverter;

public class MainActivity extends AppCompatActivity implements View.OnClickListener {

    String pais = "";
    String ciudad = "";
    Button buscar;
    TextView temp;
    TextView estadisticas;
    /**
     * ATTENTION: This was auto-generated to implement the App Indexing API.
     * See https://g.co/AppIndexing/AndroidStudio for more information.
     */
    private GoogleApiClient client;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);


        buscar = (Button) findViewById(R.id.buttonBuscar);

        buscar.setOnClickListener(this);

    public void onClick(View v) {

        EditText nombrePais = (EditText) findViewById(R.id.editTextPais);
        pais = nombrePais.getText().toString();

        EditText nombreCiudad = (EditText) findViewById(R.id.editTextCiudad);
        ciudad = nombreCiudad.getText().toString();

        String url = "http://api.openweathermap.org/data/2.5/weather?q=" + ciudad + "&APPID=faecd119485e934496d90574a6e29116&units=metric";
        new ReadJSONFeed().execute(url);

    }

    // Debolvera una cadena de tipo JSON
    private class ReadJSONFeed extends AsyncTask<String, String, String> {
        protected void onPreExecute() {

        }

        @Override
        protected String doInBackground(String... urls) {
            HttpClient httpclient = new DefaultHttpClient();
            StringBuilder builder = new StringBuilder();
            HttpPost httpPost = new HttpPost(urls[0]);
            try {
                HttpResponse response = httpclient.execute(httpPost);
                StatusLine statusLine = response.getStatusLine();
                int statusCode = statusLine.getStatusCode();
                if (statusCode == 200) {
                    HttpEntity entity = response.getEntity();
                    InputStream content = entity.getContent();
                    BufferedReader reader = new BufferedReader(new InputStreamReader(content));
                    String line;
                    while ((line = reader.readLine()) != null) {
                        builder.append(line);
                    }
                }

            } catch (Exception e) {
                e.printStackTrace();
            }
            return builder.toString();
        }

        protected void onPosExecute(String resultado) {
            try {
                JSONObject jsonObject = new JSONObject(resultado);
                String tec = jsonObject.getString("id");
                temp = (TextView) findViewById(R.id.textViewtemp);
                temp.setText(tec);

                JSONObject jwesonObject = new JSONObject(resultado);
                String tevgc = jwesonObject.getString("id");
                estadisticas = (TextView) findViewById(R.id.textViewEstadistics);
            } catch (Exception e) {

            }
        }

    }


}

